﻿namespace SignR.Entitylayer.Entites
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public List<Product> Products { get; set; }
    }
}