﻿namespace BookStore.Core.Core.Interfaces
{
    public interface ICommandPresenterFactory
    {
        IBookInventory BookInventory { get; set; }

        IPresenter BuildPresnter(string[] commandToBuild);
    }
}