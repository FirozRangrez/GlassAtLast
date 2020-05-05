using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using GlassProject.Models;
namespace GlassProject
{
    public class AddCustomer
    {
        public int Addcustomer(SignUp model)
        {
            using (var context = new GlassDatabaseEntities())
            {
                GlassCustomerSignup Gp = new GlassCustomerSignup()
                {
                    Name = model.MName,
                    Gender = model.MGender,
                    Mail = model.MMail,
                    PhoneNum = model.MMobileNumber,
                    Password = model.MPassword,
                    BuildNo = model.MBuildingNumber,
                    Landmark = model.MLandmark,
                    State = model.Mstate,
                    City=model.Mcity,
                    Pincode = model.MPincode
                };
                context.GlassCustomerSignup.Add(Gp);
                context.SaveChanges();
                return Gp.id;
            }
        }
        public SignUp Details(int id)
        {
            using (var context=new GlassDatabaseEntities())
            {
                var result = context.GlassCustomerSignup.Where(x=>x.id==id).Select(x => new SignUp()
                {
                    id=x.id,
                    MName=x.Name,
                    MGender=x.Gender,
                    MMail=x.Mail,
                    MBuildingNumber=x.BuildNo,
                    MLandmark=x.Landmark,
                    MMobileNumber=x.PhoneNum,
                    MPassword=x.Password,
                    MPincode=x.Pincode,
                    Mcity=x.City,
                    Mstate = x.State
                }).FirstOrDefault();
                return result;
            }
        }
        public SignUp GetCustomer(int id)
        {
            using (var context = new GlassDatabaseEntities())
            {
                var res = context.GlassCustomerSignup.Where(x => x.id == id).Select(x => new SignUp()
                {
                    id = x.id,
                    MName=x.Name,
                    MPassword=x.Password,
                    MGender=x.Gender,
                    MMail=x.Mail,
                    MBuildingNumber=x.BuildNo,
                    MLandmark=x.Landmark,
                    MMobileNumber = x.PhoneNum,
                    MPincode = x.Pincode,
                    Mcity=x.City,
                    Mstate = x.State
                }).FirstOrDefault();
                return res;
            }
        }
        public bool UpdateCustomer(decimal id, SignUp model)
        {
            using (var context = new GlassDatabaseEntities())
            {
                var cus = context.GlassCustomerSignup.FirstOrDefault(x => x.id == id);
                if (cus != null)
                {
                    cus.Name = model.MName;
                    cus.Gender = model.MGender;
                    cus.Password = model.MPassword;
                    cus.PhoneNum = model.MMobileNumber;
                    cus.Pincode = model.MPincode;
                    cus.State = model.Mstate;
                    cus.BuildNo = model.MBuildingNumber;
                    cus.Landmark = model.MLandmark;
                    cus.City = model.Mcity;
                    cus.Mail = model.MMail;
                }
                context.SaveChanges();
                return true;
            }
        }
        public int AddProduct(Product model) 
        {
            using (var context = new GlassDatabaseEntities())
            {
                ProductDescription p = new ProductDescription()
                {
                    Pid = model.Pid,
                    ProductName = model.PProductName,
                    length = model.Plength,
                    breadth = model.Pbreadth,
                    polish = model.Ppolish,
                    TotalPrice = model.PTotalPrice,
                    Mail = model.PMail,
                    mobileno = model.Pmobileno,
                    UserName = model.PUserName,
                    Sqft=model.PSqft,
                    LandMark=model.PLandMark,
                    State=model.PState,
                    City =model.PCity,
                    Pincode=model.PPincode,
                    BuildingNo=model.PBuildingNo,
                    OrderImage=model.POrderImage,
                    ProductType=model.PProductType
                };
                try
                {
                    context.ProductDescription.Add(p);
                    context.SaveChanges();
                    return p.Pid;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }

        public List<Product> GetProducts(Product model) 
        {
            using (var context = new GlassDatabaseEntities()) 
            {
                var result = context.ProductDescription.Where(x => x.Mail == model.PMail).Select(x => new Product()
                {
                    Pid = x.Pid,
                    PUserName = x.UserName,
                    PMail = x.Mail,
                    Pmobileno = x.mobileno,
                    PPincode = x.Pincode,
                    PBuildingNo = x.BuildingNo,
                    PLandMark = x.LandMark,
                    PCity = x.City,
                    PProductName = x.ProductName,
                    Pbreadth = x.breadth,
                    Plength = x.length,
                    Ppolish = x.polish,
                    PSqft = x.Sqft,
                    PState = x.State,
                    PTotalPrice = x.TotalPrice,
                    POrderImage=x.OrderImage,
                    PProductType=x.ProductType
                }).ToList();
                return result;
            };
        }
        public bool Delete(int id) 
        {
            using (var context=new GlassDatabaseEntities())
            {
                var Del = context.ProductDescription.FirstOrDefault(x => x.Pid == id);
                if (Del != null) 
                {
                    context.ProductDescription.Remove(Del);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}