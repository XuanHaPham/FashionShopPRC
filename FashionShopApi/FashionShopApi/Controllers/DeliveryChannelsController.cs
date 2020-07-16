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
    public class DeliveryChannelsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/DeliveryChannels
        public IQueryable<DeliveryChannel> GetDeliveryChannels()
        {
            return db.DeliveryChannels;
        }

        // GET: api/DeliveryChannels/5
        [ResponseType(typeof(DeliveryChannel))]
        public IHttpActionResult GetDeliveryChannel(int id)
        {
            DeliveryChannel deliveryChannel = db.DeliveryChannels.Find(id);
            if (deliveryChannel == null)
            {
                return NotFound();
            }

            return Ok(deliveryChannel);
        }

        // PUT: api/DeliveryChannels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeliveryChannel(int id, DeliveryChannel deliveryChannel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryChannel.Id)
            {
                return BadRequest();
            }

            db.Entry(deliveryChannel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryChannelExists(id))
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

        // POST: api/DeliveryChannels
        [ResponseType(typeof(DeliveryChannel))]
        public IHttpActionResult PostDeliveryChannel(DeliveryChannel deliveryChannel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliveryChannels.Add(deliveryChannel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deliveryChannel.Id }, deliveryChannel);
        }

        // DELETE: api/DeliveryChannels/5
        [ResponseType(typeof(DeliveryChannel))]
        public IHttpActionResult DeleteDeliveryChannel(int id)
        {
            DeliveryChannel deliveryChannel = db.DeliveryChannels.Find(id);
            if (deliveryChannel == null)
            {
                return NotFound();
            }

            db.DeliveryChannels.Remove(deliveryChannel);
            db.SaveChanges();

            return Ok(deliveryChannel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryChannelExists(int id)
        {
            return db.DeliveryChannels.Count(e => e.Id == id) > 0;
        }
    }
}