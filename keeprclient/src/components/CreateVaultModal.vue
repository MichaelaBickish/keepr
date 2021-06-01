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
              >
              <!-- v-model="" -->
            </div>
            <div class="form-group">
              <label for="description">Description</label>
              <input type="text"
                     class="form-control"
                     id="description"
                     placeholder="Description..."
                     required
              >
              <!-- v-model="" -->
            </div>

            <div class="form-group">
              <label for="imgUrl">Image Url</label>
              <input type="text" class="form-control" id="imgUrl" placeholder="Url...">
            <!-- v-model -->
            </div>
            <div class="form-group">
              <label for="isPrivate">Private?</label>
              <input type="checkbox"
                     class="form-control active-cursor"
                     id="isPrivate"
              >
            <!-- v-model="" -->
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
export default {
  name: 'CreateVaultModal',
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.active-cursor{
  cursor: pointer;
}
</style>
