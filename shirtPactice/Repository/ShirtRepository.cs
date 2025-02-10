using shirtPactice.Modal;
namespace shirtPactice.Repository
{
    public static class ShirtRepository
    {
        static List<Shirt> shirts = new List<Shirt>()

         {
            new Shirt
                {
                    shirtId = 1,
                    shirtName = "T-Shirt",
                    shirtDescription = "A casual t-shirt",
                    gender = "Male",
                    size = 42,
                    shirtModel = "Model A"
                },
                new Shirt
                {
                    shirtId = 2,
                    shirtName = "Polo Shirt",
                    shirtDescription = "A formal polo shirt",
                    gender = "Female",
                    size = 38,
                    shirtModel = "Model B"
                }  // You can add as many as you want
        };

        public static bool exitsShirt(int id)
        {
            return shirts.Any(shirt => shirt.Equals(id));
        }
        public  static  Shirt? getShirtbyId(int id)
        {
            return shirts.FirstOrDefault(shirt => shirt.shirtId == id);
        }

    }
}
