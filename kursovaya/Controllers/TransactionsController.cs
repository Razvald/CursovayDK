using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using rlf.Data;
using rlf.Data.interfaces;
using rlf.Data.Models;
using rlf.ViewModels;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace rlf.Controllers
{
    public class TransactionsController(AppDBContent db) : Controller
    {
        private readonly AppDBContent _db = db;

        // GET: Transactions/List
        public IActionResult List(int? userId)
        {
            if (userId == null)
            {
                // Если значение userId не передано, перенаправляем пользователя на страницу авторизации или другую страницу, если необходимо
                return RedirectToAction("Login", "Account"); // Замените на нужный маршрут
            }

            ViewBag.Title = "Управление личными финансами";

            // Получаем список транзакций для указанного пользователя
            List<Transaction> userTransactions = _db.Transaction
                .Where(t => t.UserId == userId)
                .Join(_db.Category,
                      transaction => transaction.CategoryID,
                      category => category.Id,
                      (transaction, category) => new { Transaction = transaction, Category = category })
                .Select(joined => joined.Transaction)
                .ToList();


            // Рассчитываем общий доход и расход
            decimal totalIncome = 0;
            decimal totalExpense = 0;

            foreach (var transaction in userTransactions)
            {
                if (transaction.CategoryID == 1) // Доходы
                {
                    totalIncome += transaction.Sum;
                }
                else // Расходы
                {
                    totalExpense += transaction.Sum;
                }
            }

            // Рассчитываем баланс
            decimal balance = totalIncome - totalExpense;

            // Создаем объект модели представления с данными для отображения на странице
            TransactionsListViewModel viewModel = new TransactionsListViewModel
            {
                UserId = userId.Value, // Получаем значение userId, предполагая, что оно не равно null
                GetAllTransactions = userTransactions,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = balance // Добавляем баланс в модель представления
            };

            return View(viewModel);
        }

        // GET: Transactions/Create
        public IActionResult Create(int userId)
        {
            // Получаем список категорий из базы данных
            var categories = _db.Category.ToList();

            // Помещаем список категорий в ViewBag
            ViewBag.Categories = categories;

            // Создаем новую транзакцию с указанным UserId
            var transaction = new Transaction
            {
                UserId = userId
            };

            // Возвращаем представление с формой для создания транзакции
            return View(transaction);
        }

        // POST: Transactions/Create
        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                // Проверяем, существует ли пользователь с указанным UserId
                var user = _db.Users.Find(transaction.UserId);
                if (user == null)
                {
                    ModelState.AddModelError("UserId", "User not found");
                    return View(transaction);
                }

                // Проверяем, существует ли категория с указанным CategoryId
                var category = _db.Category.Find(transaction.CategoryID);
                if (category == null)
                {
                    ModelState.AddModelError("CategoryId", "Category not found");
                    return View(transaction);
                }

                // Если пользователь и категория существуют, добавляем новую транзакцию
                _db.Transaction.Add(transaction);
                _db.SaveChanges();

                // После успешного создания транзакции перенаправляем пользователя на страницу со списком всех транзакций
                return RedirectToAction("List", "Transactions", new { userId = transaction.UserId });
            }

            // Если данные формы некорректны, возвращаем страницу с формой и ошибками валидации
            return View(transaction);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
