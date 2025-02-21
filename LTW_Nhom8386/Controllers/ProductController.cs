using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Repositories;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public IActionResult Index()
    {
        var products = _productRepository.GetAll();
        return View(products);
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            return View(product);
        }

        _productRepository.Add(product);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null) return NotFound();

        ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
        return View(product);
    }
    [HttpPost]
    public IActionResult Update(Product product)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_categoryRepository.GetAll(), "Id", "Name");
            return View(product);
        }

        _productRepository.Update(product);
        return RedirectToAction("Index");
    }



    public IActionResult Delete(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null) return NotFound();

        return View(product);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    public IActionResult DeleteConfirmed(int id)
    {
        _productRepository.Delete(id);
        return RedirectToAction("Index");
    }
}
