<template>
  <div class="profile-page">
    <h1>Profile page</h1>
  </div>
</template>

<script>
import { useRoute } from 'vue-router'
import Notification from '../utils/Notification'
import { AppState } from '../AppState'
import { computed, reactive, onMounted } from 'vue'
import { profilesService } from '../services/ProfilesService'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      profile: computed(() => AppState.activeProfile)
    })
    onMounted(async() => {
      try {
        await profilesService.getActiveProfile(route.params.id)
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      state,
      route
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
