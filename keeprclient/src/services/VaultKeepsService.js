import { api } from './AxiosService'
import { AppState } from '../AppState'
class VaultKeepsService {
  async createVaultKeep(newVaultKeep) {
    await api.post('api/vaultkeeps/', newVaultKeep)
  }

  async deleteVaultKeep(id) {
    await api.delete('api/vaultkeeps/' + id)
    AppState.vaultKeeps = AppState.vaultKeeps.filter(k => k.id !== id)
  }
}

export const vaultKeepsService = new VaultKeepsService()
