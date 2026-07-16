using Kds.Application.Interface;
using Kds.Application.UnitOfWork;
using Kds.Domain.Enums;
using Kds.Domain.Exceptions.Kot;

namespace Kds.Application.Services
{
	public class KotService : KotServiceInterface
	{
		private readonly KotRepositoryInterface _kotRepository;
		private readonly UnitOfWorkInterface _unitOfWork;
		public KotService(KotRepositoryInterface kotRepository,
			UnitOfWorkInterface unitOfWork)
		{
			_kotRepository = kotRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task MarkKotAsCancelled(long kotId)
		{
			var kot = await _kotRepository.GetKotByIdAsync(kotId).ConfigureAwait(false) ?? throw new KotNotFoundException(kotId);
			if (kot.Status == KotStatusEnum.Cancelled) throw new KotAlreadyCancelledException(kotId);
			kot.MarkAsCancelled();
			await _unitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
		}

		public async Task MarkKotAsPreparationStarted(long kotId)
		{
			var kot = await _kotRepository.GetKotByIdAsync(kotId).ConfigureAwait(false) ?? throw new KotNotFoundException(kotId);
			if (kot.Status == KotStatusEnum.Cancelled) throw new KotAlreadyCancelledException(kotId);
			if (kot.Status == KotStatusEnum.Ready) throw new KotAlreadyReadyException(kotId);
			if (kot.Status == KotStatusEnum.Preparing) throw new KotAlreadyPreparationStartedException(kotId);
			kot.MarkAsPreparationStarted();
			await _unitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
		}

		public async Task MarkKotAsReady(long kotId)
		{
			var kot = await _kotRepository.GetKotByIdAsync(kotId).ConfigureAwait(false) ?? throw new KotNotFoundException(kotId);
			if (kot.Status == KotStatusEnum.Cancelled) throw new KotAlreadyCancelledException(kotId);
			if (kot.Status == KotStatusEnum.Ready) throw new KotAlreadyReadyException(kotId);
			kot.MarkAsReady();
			await _unitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
		}
	}
}
