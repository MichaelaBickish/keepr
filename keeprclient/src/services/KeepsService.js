import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async createKeep(newKeep) {
    const res = await api.post('api/keeps', newKeep)
    AppState.keeps.push(res.data)
  }

  async deleteKeep(activeKeep) {
    await api.delete('api/keeps/' + activeKeep.id)
    AppState.keeps = AppState.keeps.filter(k => k.id !== activeKeep.id)
  }

  // async createVaultKeep() {
  //   await api.post('api/vaultkeeps/' + vaultId + '/')
  // }
}

export const keepsService = new KeepsService()
