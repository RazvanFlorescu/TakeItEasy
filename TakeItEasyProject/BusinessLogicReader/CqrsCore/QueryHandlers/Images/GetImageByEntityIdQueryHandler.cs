using System;
using System.Text;
using AutoMapper;
using BusinessLogicCommon.QueryHandlers;
using BusinessLogicReader.CqrsCore.Queries.Images;
using BusinessLogicReader.QueryBuilders;
using DataAccessReader.Abstractions;
using EnsureThat;
using Entities;
using Models;

namespace BusinessLogicReader.CqrsCore.QueryHandlers.Images
{
    public class GetImageByEntityIdQueryHandler : IQueryHandler<GetImageByEntityIdQuery, ImageDto>
    {
        private readonly IRepository _repository;

        public GetImageByEntityIdQueryHandler(IRepository repository)
        {
            EnsureArg.IsNotNull(repository);

            _repository = repository;
        }

        public ImageDto Handle(GetImageByEntityIdQuery query)
        {
            Image imageResult = _repository.ExecuteQueryFirstOrDefault<Image>(
                ImageQueryBuilder.GetByEntityId(query.EntityId));


            ImageDto imageDto = new ImageDto
            {
                EntityId = imageResult.EntityId.ToString(),
                Content = Encoding.UTF8.GetString(imageResult.Content)
            };

            return imageDto;
        }
    }
}
