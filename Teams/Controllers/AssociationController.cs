using API.Teams.AssociationDTOs;

namespace API.Teams.Controllers;

public class AssociationController(IRepository<Association> associationRepository)
{
    public async Task<string> CreateAssociation(AssociationCreate associationCreate)
    {
        try
        {
            Association newAssociation = new Association
            {
                Name = associationCreate.Name,
                Logo = associationCreate.imageName
            };

            await associationRepository.AddAsync(newAssociation);
            
            var succes = "Association created:  " + newAssociation.Name;
            return succes;
        }
        catch (Exception e) // 100
        {
            var error = "Creation of Association failed: " + e.Message;
            return error;
        }
    }   
}