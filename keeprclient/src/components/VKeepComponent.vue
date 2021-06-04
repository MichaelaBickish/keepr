<template>
  <!-- card start -->
  <div class="card text-white shadow">
    <img :src="keep.img" class="card-img" alt="...">
    <a href="" data-toggle="modal" data-target="#keep-modal"></a>
    <div class="card-img-overlay d-flex flex-column justify-content-between">
      <!-- <i class="fas fa-times text-danger mx-2 action" title="Delete this keep from the vault" @click="deleteVaultKeep(id)" v-if="state.account.id == state.activeVault.creatorId"></i>
      <div v-else></div> -->
      <div></div>
      <div>
        <!-- Button trigger modal -->
        <button type="button" class="btn btn-outline-transparent mx-2" data-toggle="modal" data-target="#keep-modal" @click="setActiveKeep()">
          <p class="card-title mb-0 text-white font-weight-bold" title="View Keep">
            {{ keep.name }}
          </p>
        </button>
        <router-link :to="{name: 'ProfilePage', params:{id: keep.creator.id}}">
          <img :src="keep.creator.picture" class="rounded-circle mx-2 creator-img mb-1" title="View Profile" alt="">
        </router-link>
      </div>
      <!-- </div> -->
    </div>
  </div>
  <!-- End card -->
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { vaultKeepsService } from '../services/VaultKeepsService'
import Notification from '../utils/Notification'
export default {
  name: 'VKeepComponent',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      activeVault: computed(() => AppState.activeVault),
      account: computed(() => AppState.account),
      vaultKeeps: computed(() => AppState.vaultKeeps)
    })
    return {
      state,
      setActiveKeep() {
        AppState.activeKeep = props.keep
      },
      async deleteVaultKeep(id) {
        try {
          debugger
          if (await Notification.confirmAction('Delete This Keep?', 'It will be deleted out of your vault permanently', 'warning', 'Yes, Delete Keep!')) {
            await vaultKeepsService.deleteVaultKeep(id)
            Notification.toast('Keep has been removed from this vault!', 'success')
          }
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
// .creator-img{
//   height: 2rem;
//   width: ;
// }
@media(min-width: 1px){
  .creator-img{
    height: 1.5rem;
    width: 1.5rem;
   }
   .action{
     cursor: pointer;
   }
}
// @media(max-width: 500px){
//   .creator-img{
//     height: 1.5rem;
//     width: 1.5rem;
// }
// }

</style>
