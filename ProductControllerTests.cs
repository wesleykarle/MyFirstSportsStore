﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MyFirstSportsStore.Models;
using MyFirstSportsStore.Controllers;
using Xunit;
using Moq;
using MyFirstSportsStore.Models.ViewModels;

namespace MyFirstSportsStore
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Send_Pagination_View_Model()
        {

            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
            new Product {ProductID = 1, Name = "P1"},
            new Product {ProductID = 2, Name = "P2"},
            new Product {ProductID = 3, Name = "P3"},
            new Product {ProductID = 4, Name = "P4"},
            new Product {ProductID = 5, Name = "P5"}
        }).AsQueryable<Product>());

            // Arrange
            ProductController controller =
                new ProductController(mock.Object) { PageSize = 3 };

            // Act
            ProductsListViewModel result =
                controller.List(2).ViewData.Model as ProductsListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);
        }
    }
}
