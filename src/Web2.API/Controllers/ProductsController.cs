using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2.API.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<EtudiantsController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Product.products;
        }


        /// <summary>
        /// Retourne un étudiant specifique à partir de son id
        /// </summary>
        /// <remarks>Je manque d'imagination</remarks>
        /// <param name="id">id de l'étudiant à retourner</param>   
        /// <response code="200">étudiant trouvé et retourné</response>
        /// <response code="404">étudiant introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        // GET api/<EtudiantsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = Product.products.ToList().FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return product;
        }

        // POST api/<EtudiantsController>
        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                Product.products.Add(product);
                return CreatedAtAction(nameof(Post), new { id = product.Id }, product);
            }

            return BadRequest();
        }
        // PUT api/<EtudiantsController>/5
       /* [HttpPut("{id}")]
        public IActionResult Put(int id, Etudiant etudiant)
        {
            if (id != etudiant.Id)
                return BadRequest();

            var etudiantExistant = EtudiantService.Obtenir(id);
            if (etudiantExistant is null)
                return NotFound();

            EtudiantService.Modifier(etudiant);

            return NoContent();
        }*/

        // DELETE api/<EtudiantsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = Product.products.ToList().FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            Product.products.Remove(product);

            return NoContent();
        }
    }
}

