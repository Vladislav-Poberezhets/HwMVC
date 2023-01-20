namespace HwMVC.Products
{
    public class Product
    {
       
        public int Id { get; set; }
            public string? ProductName { get; set; } 
            public int Price { get; set; }
        public Product()
        {

        }
        public Product(int i, string y, int x)
        {
            ProductName = y;
            Price = x;
                
        }

        

      
        
    }
    
}
