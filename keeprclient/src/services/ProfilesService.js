import { AppState } from '../AppState'
import { api } from './AxiosService'
class ProfilesService {
  async getActiveProfile(id) {
    const res = await api.get('api/profiles/' + id)
    AppState.activeProfile = res.data
  }

  async getProfileKeeps(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    AppState.profileKeeps = res.data
  }

  // async getProfileVaults(id) {
  //   const res = await api.get('api/profiles/' + id + '/vaults')
  //   AppState.profileVaults = res.data
  // }
}
export const profilesService = new ProfilesService()
