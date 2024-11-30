﻿using LoadDwh.Data.Contexts;
using LoadDwh.Data.Entites.DwOrders;
using LoadDwh.Data.Entites.Northwind;
using LoadDwh.Data.Entities.DwOrders;
using LoadDwh.Data.Results;
using Microsoft.EntityFrameworkCore;

namespace LoadDwh.Data.Interfaces.DwOrders
{
    public class DataServiceDwOrders : IDataServiceDwOrders
    {
        private readonly NorthwindContext _northwind;
        private readonly DbOrderContext _dbOrderContext; 

        public DataServiceDwOrders(DbOrderContext dbOrderContext, NorthwindContext northwind)
        {
            _dbOrderContext = dbOrderContext;
            _northwind = northwind;
        }

        public async Task<OperationResults> LoadDw()
        {
            OperationResults result = new OperationResults();
           
            try
            {
                //await LoadDimEmployee();
                //await LoadDimCategory();
                //await LoadDimProducts();
                await LoadDimCustomers();
                await LoadDimShippers();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading the data warehouse.{ex.Message}";
            }

            return result;
        }

        private async Task<OperationResults> LoadDimCategory()
        {
            OperationResults result = new OperationResults();

            try
            {
                //Obtener empleadoso de la base de datos de northwind
                var categories = _northwind.Categories.AsNoTracking().Select(cat => new DimCategory()
                {
                    CategoryName = cat.CategoryName
                }).ToList();

                //Cargar los datos a la tabla de Dimension de producto
                await _dbOrderContext.DimCategories.AddRangeAsync(categories);
                await _dbOrderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading DimCategory.{ex.Message}";
            }

            return result;
        }

        private async Task<OperationResults> LoadDimEmployee()
        {
            OperationResults result = new OperationResults();

            try
            {
                //Obtener empleadoso de la base de datos de northwind
                var employees = _northwind.Employees.AsNoTracking().Select(emp => new DimEmployee()
                {
                    EmployeeKey = emp.EmployeeID,
                    Name = string.Concat(emp.FirstName, " ", emp.LastName)
                }).ToList();

                //Cargar los empleados en la tabla de Dimension
                await _dbOrderContext.DimEmployees.AddRangeAsync(employees);
                await _dbOrderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading DimEmployees.{ex.Message}";
            }

            return result;
        }

        private async Task<OperationResults> LoadDimProducts()
        {
            OperationResults result = new OperationResults();

            try
            {
                //Obtener productos de la base de datos de northwind
                var product = _northwind.Products.AsNoTracking().Select(prod => new DimProduct()
                {
                    ProductName = prod.ProductName
                }).ToList();

                await _dbOrderContext.DimProducts.AddRangeAsync(product);
                await _dbOrderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading DimProduct.{ex.Message}";
            }

            return result;
        }

        private async Task<OperationResults> LoadDimCustomers()
        {
            OperationResults result = new OperationResults();

            try
            {
                //Obtener productos de la base de datos de northwind
                var customers = _northwind.Customers.AsNoTracking().Select(custo => new DimCustomer()
                {
                    CustomerID = custo.CustomerID,
                    City = custo.City,
                    CompanyName = custo.CompanyName,
                    Country = custo.Country,
                    ContactName = custo.ContactName,
                }).ToList();

                await _dbOrderContext.DimCustomers.AddRangeAsync(customers);
                await _dbOrderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading DimCustomers.{ex.Message}";
            }

            return result;
        }

        private async Task<OperationResults> LoadDimShippers()
        {
            OperationResults result = new OperationResults();

            try
            {
                //Obtener productos de la base de datos de northwind
                var shippers = _northwind.Shippers.AsNoTracking().Select(ship => new DimShipper()
                {
                    CompanyName = ship.CompanyName
                }).ToList();

                await _dbOrderContext.DimShippers.AddRangeAsync(shippers);
                await _dbOrderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"An error has ocurred loading DimShippers.{ex.Message}";
            }

            return result;
        }


    }
}
