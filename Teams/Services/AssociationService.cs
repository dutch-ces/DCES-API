using System.Data.Entity;

public class AssociationService(IRepository<Association> associationRepository)
{
    public async Task<Association> CreateAssociation(AssociationCreate associationCreate, CancellationToken cancellationToken)
    {
        if (associationCreate == null || associationCreate.ImageName == null || associationCreate.Name == null)
        {
            throw new Exception("Association Create DTO has members missing or is null");
        }
        
        var association = new Association
        {
            Name = associationCreate.Name,
            Logo = associationCreate.ImageName
        };
        
        await associationRepository.AddAsync(association, cancellationToken);
        await associationRepository.SaveChangesAsync(cancellationToken);
        return association;
    }

    public async Task<Association> GetAssociationById(Guid associationId, CancellationToken cancellationToken)
    {
        var association = await associationRepository.GetByIdAsync(associationId, cancellationToken);

        return association ?? throw new Exception("Association with ID " + associationId + " not found");
    }

    public async Task<List<Association>> GetAssociationsByName(string? associationName, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(associationName))
        {
            throw new Exception("Search term is empty");
        }

        List<Association> associations =
            await associationRepository.Query().Where(a => a.Name.Contains(associationName)).ToListAsync(cancellationToken);
        
        return associations;
    }

    public async Task<List<Association>> GetAllAssociatios(CancellationToken cancellationToken)
    {
        var associations = await associationRepository.Query().ToListAsync(cancellationToken);
        return associations;
    }
}