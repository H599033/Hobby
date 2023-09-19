using System;

namespace Hobby.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Ekstra { get; set; } //må legges til i ViewM med getter setter
    }
}
