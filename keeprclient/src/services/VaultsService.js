import { AppState } from '../AppState'
import router from '../router'
import { api } from './AxiosService'
class VaultsService {
  async createVault(newVault) {
    const res = await api.post('api/vaults', newVault)
    AppState.vaults.push(res.data)
  }

  async getVaultById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
  }

  async deleteVault(activeVault) {
    await api.delete('api/vaults/' + activeVault.id)
    AppState.vaults = AppState.vaults.filter(v => v.id !== activeVault.id)
    router.push({ name: 'ProfilePage', params: { id: activeVault.creatorId } })
  }

  async getVaultKeeps(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    AppState.vaultKeeps = res.data
  }
}

export const vaultsService = new VaultsService()
