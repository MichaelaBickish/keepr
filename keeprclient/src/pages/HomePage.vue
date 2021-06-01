<template>
  <div class="container-fluid">
    <div class="row my-3 mx-1">
      <!-- {{ state.keeps }} -->
      <!-- <div class=""> -->
      <div class="card-columns">
        <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
      </div>
      <!-- </div> -->
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import Notification from '../utils/Notification'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps)
    })
    onMounted(async() => {
      try {
        await keepsService.getAll()
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      state
    }
  }
}
</script>

<style scoped lang="scss">
// .card-columns {
//   column-span: 4;
// }
</style>
