namespace BookStore.Core.Core.Interfaces
{
    public interface ICommandFactory
    {
        IBookInventory BookInventory { get; set; }

        ICommand BuildCommand(string[] commandToBuild);
    }
}