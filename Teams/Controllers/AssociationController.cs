public class AssociationController(AssociationService  associationService)
{
    public async Task<string> CreateAssociation(AssociationCreate associationCreate, CancellationToken cancellationToken)
    {
        try
        {
                var newAssociation = await associationService.CreateAssociation(associationCreate, cancellationToken);
                
                var success = "Association created:  " + newAssociation.Name;
                return success;
        }
        catch (Exception e) // 100
        {
            var error = "Creation of Association failed: " + e.Message;
            return error;
        }
    }   
}