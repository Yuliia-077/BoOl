using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoOl.ViewModels
{
    public class SelectedModel
    {
        public int Value { get; set; }
        public string Text { get; set; }

        public SelectedModel(int value, string text)
        {
            Value = value;
            Text = text;
        }
    }
}
