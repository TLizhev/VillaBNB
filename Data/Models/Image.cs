﻿namespace VillaBNB.Data.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string ImageUrl { get; set; }

        public string Extensions { get; set; }

        public int VillaId { get; set; }

        public virtual Villa Villa { get; set; }

    }
}