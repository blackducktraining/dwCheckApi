namespace dwCheckApi.DAL 
{
    public interface IDatabaseService
    {
        bool ClearDatabase();

        int SeedDatabase();
    }
}