using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Web2.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web2.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProductsController : ControllerBase
    {
        public static List<Product> products = new List<Product>();



        // GET: api/<EtudiantsController>
        /// <summary>
        /// Retourne une liste de produists
        /// </summary>
        /// /// <response code="200">Les produits ont été trouvés et retournés</response>
        /// <response code="404">produit introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }


        /// <summary>
        /// Retourne un produit specifique à partir de son id
        /// </summary>        
        /// <param name="id">id du produit à retourner</param>   
        /// <response code="200">produit trouvés et retourné</response>
        /// <response code="404">produit introuvable pour l'id specifié</response>
        /// <response code="500">Oops! le service est indisponible pour le moment</response>
        // GET api/<EtudiantsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        public ActionResult<Product> Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return product;
        }


        /// <summary>
        /// Créé un produit à partir du formulaire rempli par l'utilisateur
        /// </summary>
        /// <param name="product"></param>
        /// <response code="200"> Le produit est créé avec succès</response>
        /// <response code="201"> Le produit est créé et retourné</response>
        /// <response code="400"> Mauvaise requête, Erreur dans la validation du formulaire</response>
        /// <response code="204"> Le produit n'a pu être créé</response>
        /// /// <response code="500">Oops! le service est indisponible pour le moment</response>
        /// <returns></returns>
        // POST api/<EtudiantsController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]        
        public IActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return CreatedAtAction(nameof(Post), new { id = product.Id }, product);
            }

            return BadRequest();
        }

        // PUT api/<EtudiantsController>/5
        /* [HttpPut("{id}")]
         public IActionResult Put(int id, Produit produit)
         {
        
             if (id != produit.Id)
                 return BadRequest();

            var product = products.FirstOrDefault(p => p.Id == id);
             if (product is null)
                 return NotFound();
        produits.remove(product);
        produits.Add(produit);
                    return produit;
         }*/

        /// <summary>
        /// Supprime un produit à partir de son ID
        /// </summary>
        /// <param name="id">identifiant du produit</param>
        /// <response code="204"> Le produit est supprimé avec succès</response>
        /// <response code="400"> Le produit est introuvale</response>
        /// /// <response code="500">Oops! le service est indisponible pour le moment</response>
        /// <returns></returns>
        // DELETE api/<EtudiantsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Product), 204)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product is null)
                return NotFound();

            products.Remove(product);

            return NoContent();
        }
    }
}

