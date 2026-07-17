using Kds.Application.Interface;
using Kds.Application.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Services
{
	public class SequenceService : SequenceServiceInterface
	{
		private readonly SequenceRepositoryInterface _sequenceGeneratorRepository;
		private readonly UnitOfWorkInterface _unitOfWorkInterface;
		public SequenceService(SequenceRepositoryInterface sequenceGeneratorRepository, UnitOfWorkInterface unitOfWorkInterface)
		{
			_sequenceGeneratorRepository = sequenceGeneratorRepository;
			_unitOfWorkInterface = unitOfWorkInterface;
		}
		public async Task<long> GenerateSequenceId(string sequenceKey, string sequenceGroup, long defaultValue = 1)
		{
			var x = await _sequenceGeneratorRepository.GenerateSequenceId(sequenceKey, sequenceGroup, defaultValue)
				.ConfigureAwait(false);
			await _unitOfWorkInterface.SaveChangesAsync(CancellationToken.None);
			return x;
		}
	}
}
