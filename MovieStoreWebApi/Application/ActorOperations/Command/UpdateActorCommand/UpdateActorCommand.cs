using System;
using System.Linq;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.DTo.Actor.ActorCrudModels;

namespace MovieStoreWebApi.Application.ActorOperation.Command.UpdateActorCommand
{
    public class UpdateActorCommand
    {
        IMovieStoreDbContext _context;
        public int Id;
        public UpdateActorModel updatedData;
        
        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var obj =_context.Actors.Where(M=>M.Id==Id).FirstOrDefault();
            if(obj is null)
            {
                throw new InvalidOperationException("Film Bulunamadı!");
            }
                obj.Name = (updatedData.Name == default) ? obj.Name: updatedData.Name;
                obj.Surname = (updatedData.Surname == default) ? obj.Surname: updatedData.Surname;
            _context.SaveChanges();
        }

    }
}