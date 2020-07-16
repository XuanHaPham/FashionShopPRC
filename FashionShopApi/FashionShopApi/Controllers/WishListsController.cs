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
    public class WishListsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/WishLists
        public IQueryable<WishList> GetWishLists()
        {
            return db.WishLists;
        }

        // GET: api/WishLists/5
        [ResponseType(typeof(WishList))]
        public IHttpActionResult GetWishList(int id)
        {
            WishList wishList = db.WishLists.Find(id);
            if (wishList == null)
            {
                return NotFound();
            }

            return Ok(wishList);
        }

        // PUT: api/WishLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWishList(int id, WishList wishList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wishList.Id)
            {
                return BadRequest();
            }

            db.Entry(wishList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishListExists(id))
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

        // POST: api/WishLists
        [ResponseType(typeof(WishList))]
        public IHttpActionResult PostWishList(WishList wishList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WishLists.Add(wishList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wishList.Id }, wishList);
        }

        // DELETE: api/WishLists/5
        [ResponseType(typeof(WishList))]
        public IHttpActionResult DeleteWishList(int id)
        {
            WishList wishList = db.WishLists.Find(id);
            if (wishList == null)
            {
                return NotFound();
            }

            db.WishLists.Remove(wishList);
            db.SaveChanges();

            return Ok(wishList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WishListExists(int id)
        {
            return db.WishLists.Count(e => e.Id == id) > 0;
        }
    }
}