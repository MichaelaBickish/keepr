import { api } from './AxiosService'
class VaultKeepsService {
  async createVaultKeep(newVaultKeep) {
    await api.post('api/vaultkeeps/', newVaultKeep)
  }
}

export const vaultKeepsService = new VaultKeepsService()
