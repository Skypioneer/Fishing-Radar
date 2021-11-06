using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// JsonFileProductService processes all CRUDi
    /// related implementation involved with our Json file (pseudo database)
    /// </summary>
   public class JsonFileProductService
    {
        
        // constructor for a web host object that is responsible for the startup and
        // lifetime management
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // defining webhost object
        public IWebHostEnvironment WebHostEnvironment { get; }

        // returns path adding the data and products.json to path
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// Using ProductModel deserialize Json file and returns all the
        /// products in given Json file
        /// </summary>
         

        ///REMOVE Redundant: leave just in case unforseen error. Unit tests all passed???
        public IEnumerable<ProductModel> GetProducts()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Using ProductModel deserialize Json file and returns all the
        /// products in given Json file
        /// </summary>
        public IEnumerable<ProductModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// For a given product Id assign the given rating to that particuluar 
        /// product in our JsonFile. 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public void AddRating(string productId, int rating)
        {
            //gets all of the products from Jsonfile
            var products = GetAllData();

            //check to product Id if it has no ratings array initialize one
            if(products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { rating };
            }
            // otherwise add rating to products rating array
            else
            {
                var ratings = products.First(x => x.Id == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Id == productId).Ratings = ratings.ToArray();
            }

            //Write the new data to Jsonfile to save changes
            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }), 
                    products
                );
            }
        }


        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {
            //TODO: remove getalldata and getproducts() they do the same thing

            // Get all the products from Json file
            var products = GetAllData();
            
            // gets the product from data if it exists if it doesn't return null
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            productData.Title = data.Title;
            productData.Description = data.Description.Trim();
            productData.Url = data.Url;
            productData.Image = data.Image;

            productData.Quantity = data.Quantity;
            productData.Price = data.Price;

            // save changes to Json file
            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {
            // write changes to Json file
            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <param name="data">The product to add to the JSON dataset</param>
        /// <returns></returns>
        public ProductModel CreateData(ProductModel data)
        {
            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();

            //find the product with the same ID
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            //get the new dataset excluding the element to be removed
            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            // save changes to dataset
            SaveData(newDataSet);

            return data;
        }

    }
}