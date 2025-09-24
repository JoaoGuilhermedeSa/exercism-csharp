public class Orm : IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        if (database.DbState == Database.State.Closed)
        {
            database.BeginTransaction();
        }
    }

    public void Write(string data)
    {
        if (database.DbState == Database.State.TransactionStarted)
        {
            try
            {
                database.Write(data);
            }
            catch (Exception)
            {
                database.Dispose();
            }
        }
    }

    public void Commit()
    {
        if (database.DbState == Database.State.DataWritten)
        {
            try
            {
                database.EndTransaction();
            }
            catch (Exception)
            {
                database.Dispose();
            }
        }
    }

    public void Dispose()
    {
        database.Dispose();
    }
}
