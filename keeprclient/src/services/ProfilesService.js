import { AppState } from '../AppState'
import { api } from './AxiosService'
class ProfilesService {
  async getActiveProfile(id) {
    const res = await api.get('api/profiles/' + id)
    AppState.activeProfile = res.data
  }
}
export const profilesService = new ProfilesService()
