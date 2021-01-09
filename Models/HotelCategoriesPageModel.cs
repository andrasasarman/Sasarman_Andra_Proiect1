using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sasarman_Andra_Proiect1.Data;
namespace Sasarman_Andra_Proiect1.Models
{
    public class HotelCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Sasarman_Andra_Proiect1Context context,//Metoda PopulateAssignedCategoryData citeste entitatile Category si populeaza lista AssignedCategoryDataList.
        Hotel hotel)
        {
            var allCategories = context.Category;
            var hotelCategories = new HashSet<int>(
            hotel.HotelCategories.Select(c => c.HotelID)); ;
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = hotelCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateVacanțăCategories(Sasarman_Andra_Proiect1Context context,
        string[] selectedCategories, Hotel hotelToUpdate)
        {
            if (selectedCategories == null)
            {
                hotelToUpdate.HotelCategories = new List<HotelCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var hotelCategories = new HashSet<int>
            (hotelToUpdate.HotelCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!hotelCategories.Contains(cat.ID))
                    {
                        hotelToUpdate.HotelCategories.Add(
                        new HotelCategory
                        {
                            HotelID = hotelToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (hotelCategories.Contains(cat.ID))
                    {
                        HotelCategory courseToRemove
                        = hotelToUpdate
                        .HotelCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
