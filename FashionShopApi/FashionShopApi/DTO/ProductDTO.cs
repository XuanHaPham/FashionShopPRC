﻿using FashionShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShopAPI.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Reviews { get; set; }
        public string Overview { get; set; }

        public ProductDTO(Product product)
        {
            Id = product.Id;
            Title = product.Name;
            Rating = 0;
            Reviews = product.Overview;
            Overview = product.Overview;
        }
    }
}

/*
  id: product.id,
          title: product.name,
          price: product.price,
          rating: product.ratings,
          reviews: product.reviews,
          addedBtn: product.addedBtn,
          overview: product.overview
 */
