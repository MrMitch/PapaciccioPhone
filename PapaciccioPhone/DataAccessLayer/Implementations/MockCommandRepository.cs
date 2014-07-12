﻿using PapaciccioPhone.DataAccessLayer.Interfaces;
using PapaciccioPhone.Models;
using PapaciccioPhone.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PapaciccioPhone.DataAccessLayer.Implementations
{
    public class MockCommandRepository : ICommandRepository
    {
        #region ICommandRepository Membres

        public async Task<CommandViewModel> GetCommand(DateTime date)
        {
            await Task.Delay(2000);

            return new CommandViewModel()
            {
                Id = "1",
                Timestamp = 140000000,
                Orders = new List<Order>()
                {
                    new Order()
                    {
                        Name = "Mitch",
                        Pasta = "farfalle",
                        Size = "moyen",
                        Sauces = new List<string>(){"poulet crême", "pesto rossso", "pesto verde"},
                        Toppings = new List<string>(){"gruyère"}
                    },
                    new Order()
                    {
                        Name = "BrYaN",
                        Pasta = "spagetthi",
                        Size = "maxi",
                        Sauces = new List<string>(){"bolognaise", "pesto verde", },
                        Toppings = new List<string>(){"gruyère", "parmesan"}
                    },
                    new Order()
                    {
                        Name = "chteu",
                        Pasta = "penne",
                        Size = "maxi",
                        Sauces = new List<string>(){"poulet crême", "pesto rossso", "pesto verde"},   
                    },
                    new Order()
                    {
                        Name = "Marvin",
                        Pasta = "penne",
                        Size = "maxi",
                        Sauces = new List<string>(){"carbo lardon", "poulet crême"},
                        Toppings = new List<string>(){"gruyère", "parmesan"}
                    },
                    new Order()
                    {
                        Name = "Olive",
                        Pasta = "penne",
                        Size = "maxi",
                        Sauces = new List<string>(){"saumon", "arabiatta"},
                        Toppings = new List<string>(){"gruyère", "parmesan"}
                    }
                }
            };
        }

        public Task<CommandViewModel> AddOrder(Order order, CommandViewModel command)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCommand(CommandViewModel command)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
