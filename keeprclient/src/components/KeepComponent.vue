<template>
  <!-- card start -->
  <div class="card text-white shadow">
    <img :src="keep.img" class="card-img" alt="...">
    <a href="" data-toggle="modal" data-target="#keep-modal"></a>
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <!-- Button trigger modal -->
      <button type="button" class="btn btn-outline-transparent" data-toggle="modal" data-target="#keep-modal" @click="setActiveKeep()">
        <p class="card-title mb-0 text-white font-weight-bold" title="View Keep">
          {{ keep.name }}
        </p>
      </button>
      <router-link :to="{name: 'ProfilePage', params:{id: keep.creator.id}}">
        <img :src="keep.creator.picture" class="rounded-circle creator-img mb-1" title="View Profile" alt="">
      </router-link>
    </div>
  </div>
  <!-- End card -->
</template>

<script>
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'KeepComponent',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async setActiveKeep() {
        AppState.activeKeep = props.keep
        await keepsService.getKeepById(AppState.activeKeep.id)
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
}
// @media(max-width: 500px){
//   .creator-img{
//     height: 1.5rem;
//     width: 1.5rem;
// }
// }

</style>
