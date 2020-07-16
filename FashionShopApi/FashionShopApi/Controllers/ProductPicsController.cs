using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FashionShopAPI.Models;

namespace FashionShopAPI.Controllers
{
    public class ProductPicsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ProductPics
        public IQueryable<ProductPic> GetProductPics()
        {
            return db.ProductPics;
        }

        // GET: api/ProductPics/5
        [ResponseType(typeof(ProductPic))]
        public IHttpActionResult GetProductPic(int id)
        {
            ProductPic productPic = db.ProductPics.Find(id);
            if (productPic == null)
            {
                return NotFound();
            }

            return Ok(productPic);
        }

        // PUT: api/ProductPics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductPic(int id, ProductPic productPic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productPic.Id)
            {
                return BadRequest();
            }

            db.Entry(productPic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductPics
        [ResponseType(typeof(ProductPic))]
        public IHttpActionResult PostProductPic(ProductPic productPic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductPics.Add(productPic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productPic.Id }, productPic);
        }

        // DELETE: api/ProductPics/5
        [ResponseType(typeof(ProductPic))]
        public IHttpActionResult DeleteProductPic(int id)
        {
            ProductPic productPic = db.ProductPics.Find(id);
            if (productPic == null)
            {
                return NotFound();
            }

            db.ProductPics.Remove(productPic);
            db.SaveChanges();

            return Ok(productPic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductPicExists(int id)
        {
            return db.ProductPics.Count(e => e.Id == id) > 0;
        }
    }
}