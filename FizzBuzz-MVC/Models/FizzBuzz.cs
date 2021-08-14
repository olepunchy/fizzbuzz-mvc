using System.Collections.Generic;

namespace FizzBuzz_MVC.Models {
    public class FizzBuzz {
        public int StartValue { get; set; }
        public int EndValue { get; set; } 
        public List<(string, string)> Results { get; set; } = new();
    }
}
