namespace CreateDataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseOperations databaseOperations = new DatabaseOperations();
            //databaseOperations.CreateDataBase();
            //databaseOperations.CreateTables();
            //databaseOperations.InsertBuyer();
            //databaseOperations.InsertProduct();
            //databaseOperations.addSales();
            databaseOperations.AllSalesInfo();



        }
    }
}
