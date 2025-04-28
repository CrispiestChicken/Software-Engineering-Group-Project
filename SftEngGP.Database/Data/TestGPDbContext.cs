namespace SftEngGP.Database.Data;

public class TestGPDbContext: GenericGPDbContext
{
    internal override String connectionName {get; set;} = "TestConnection";
}