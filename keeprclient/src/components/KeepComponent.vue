<template>
  <!-- card start -->
  <div class="card text-white shadow">
    <img :src="keep.img" class="card-img" alt="...">
    <a href="" data-toggle="modal" data-target="#keep-modal"></a>
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <!-- Button trigger modal -->
      <button type="button" class="btn btn-outline-transparent" data-toggle="modal" data-target="#keep-modal">
        <h5 class="card-title mb-0 text-white">
          {{ keep.name }}
        </h5>
      </button>
      <router-link :to="{name: 'ProfilePage', params:{id: keep.creator.id}}">
        <img :src="keep.creator.picture" class="rounded-circle creator-img" alt="">
      </router-link>
    </div>
  </div>
  <!-- End card -->
</template>

<script>
export default {
  name: 'KeepComponent',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
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
