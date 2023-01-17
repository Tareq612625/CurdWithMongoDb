using CurdWithMongoDb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CurdWithMongoDb.Controllers
{
    public class ProductController : Controller
    {
        MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
        public IActionResult Index()
        {
            var database = client.GetDatabase("POS");
            var table = database.GetCollection<ItemMaster>("Item");
            var items = table.Find(FilterDefinition<ItemMaster>.Empty).ToList();
            return View(items);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ItemMaster obj)
        {

            var database = client.GetDatabase("POS");
            var table = database.GetCollection<ItemMaster>("Item");
            table.InsertOne(obj);
            ViewBag.msg = "Data save successfully";
            return View();
        }

        public IActionResult Edit(int id)
        {
            var database = client.GetDatabase("POS");
            var table = database.GetCollection<ItemMaster>("Item");
            var product = table.Find(c => c.ItemId == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ItemMaster obj)
        {

            var database = client.GetDatabase("POS");
            var table = database.GetCollection<ItemMaster>("Item");
            table.ReplaceOne(c => c.ItemId == obj.ItemId, obj);
            ViewBag.msg = "Data save successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var database = client.GetDatabase("POS");
            var table = database.GetCollection<ItemMaster>("Item");
            var product = table.Find(c => c.ItemId == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(ItemMaster obj)
        {

            var database = client.GetDatabase("POS");
            var table = database.GetCollection<ItemMaster>("Item");
            table.DeleteOne(c => c.ItemId == obj.ItemId);
            ViewBag.msg = "Data save successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var database = client.GetDatabase("POS");
            var table = database.GetCollection<ItemMaster>("Item");
            var product = table.Find(c => c.ItemId == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
