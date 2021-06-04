<template>
  <div class="modal fade"
       id="new-vault-form"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            New Vault
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <form @submit.prevent="createVault">
          <div class="modal-body">
            <div class="form-group">
              <label for="name">Title</label>
              <input type="text"
                     class="form-control"
                     id="name"
                     placeholder="Name..."
                     required
                     v-model="state.newVault.name"
              >
            </div>
            <div class="form-group">
              <label for="description">Description</label>
              <input type="text"
                     class="form-control"
                     id="description"
                     placeholder="Description..."
                     required
                     v-model="state.newVault.description"
              >
            </div>

            <div class="form-group">
              <label for="imgUrl">Image Url</label>
              <input type="text" class="form-control" id="imgUrl" placeholder="Url..." v-model="state.newVault.img">
            </div>
            <div class="form-group">
              <label for="isPrivate">Private?</label>
              <input type="checkbox"
                     class="form-control active-cursor"
                     title="Check This Item"
                     id="isPrivate"
                     v-model="state.newVault.isPrivate"
              >
            </div><p class="font-weight-lighter">
              Private vaults can only be seen by you
            </p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">
              Close
            </button>
            <button type="submit" class="btn btn-primary">
              Create
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import $ from 'jquery'
import Notification from '../utils/Notification'
import { vaultsService } from '../services/VaultsService'
import { profilesService } from '../services/ProfilesService'
export default {
  name: 'CreateVaultModal',
  setup() {
    const state = reactive({
      newVault: {
        // isPrivate: false
      },
      activeProfile: computed(() => AppState.activeProfile)
    })
    return {
      state,
      async createVault() {
        try {
          await vaultsService.createVault(state.newVault)
          state.newVault = {}
          $('#new-vault-form').modal('hide')
          Notification.toast('Your New Vault Has Been Created!', 'success')
          await profilesService.getProfileVaults(state.activeProfile.id)
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
.active-cursor{
  cursor: pointer;
}
</style>
