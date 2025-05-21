using CarVilla.BL.ViewModels;
using CarVilla.DAL.Contexts;
using CarVilla.DAL.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVilla.BL.Services
{
  public  class ProductService
    {
        private readonly AppDbContext _context;
        public ProductService()
        {
            _context =  new AppDbContext();

        }

        #region Create
        public void Create( CreateVM createVM)
        {
            ProductModel product = new ProductModel();

            //maping
            product.Name = createVM.Name;
            product.Model = createVM.Model;
            product.Price = createVM.Price;

            //file upload 1 ci addim

            string filename = Path.GetFileNameWithoutExtension(createVM.Image.FileName);
            string extension = Path.GetExtension(createVM.Image.FileName);
            string fullname = filename + Guid.NewGuid().ToString() + extension;
            product.ImgUrl = fullname;

            //file upload 2 ci addim
            string uploadedPath = @"C:\Users\User\Downloads\CarVilla2\CarVilla2\CarVilla.MVC\wwwroot\assets\UploadedImages";
            uploadedPath = Path.Combine(uploadedPath,fullname);
            using FileStream stream = new FileStream(uploadedPath,FileMode.Create);
            createVM.Image.CopyTo(stream);

            _context.Add(product);
            _context.SaveChanges();
        
        }

        #endregion

        #region Read
        public ProductModel GetProductById(int? id)
        {
            if (id is null)
            {
                throw new Exception("id yaz");
            }
            ProductModel product = _context.productModels.Find(id);
            return product;

        }

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> list = _context.productModels.ToList();
            return list;
        }
        #endregion

        #region Update 
        public void Update(int id , UpdateVM updateVM)
        {
            ProductModel product = new ProductModel();

            product.Name = updateVM.Name;
            product.Model = updateVM.Model;
            product.Price = updateVM.Price;

            if ( product.ImgUrl is not  null)
            {
                //file upload 1 ci addim

                string filename = Path.GetFileNameWithoutExtension(updateVM.Image.FileName);
                string extension = Path.GetExtension(updateVM.Image.FileName);
                string fullname = filename + Guid.NewGuid().ToString() + extension;
                product.ImgUrl = fullname;

                //file upload 2 ci addim
                string uploadedPath = @"C:\Users\User\Downloads\CarVilla2\CarVilla2\CarVilla.MVC\wwwroot\assets\UploadedImages";
                uploadedPath = Path.Combine(uploadedPath, fullname);
                using FileStream stream = new FileStream(uploadedPath, FileMode.Create);
                updateVM.Image.CopyTo(stream);
            }
            _context.SaveChanges();
        }
        #endregion

        #region Delete
        public void Delete(int id)
        {
            ProductModel product = GetProductById(id);
            _context.Remove(product);
            _context.SaveChanges();
        }
        
        #endregion
    }
}
