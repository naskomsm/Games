﻿namespace MuOnline.Models.Inventories.Contracts
{
    using System.Collections.Generic;
    using Items.Contracts;

    public interface IInventory
    {
        IReadOnlyCollection<IItem> Items { get; }

        void AddItem(IItem item);

        string RemoveItem(IItem item);

        IItem GetItem(string item);
    }
}
