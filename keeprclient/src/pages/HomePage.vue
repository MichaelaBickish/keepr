<template>
  <div class="container">
    <div class="row">
      <div class="col-12 col-md-3">
        <!-- card start -->
        <div class="card text-white m-2 shadow">
          <img src="https://media-cdn.tripadvisor.com/media/photo-s/02/25/67/df/filename-homer-jpg-thumbnail0.jpg" class="card-img" alt="...">
          <div class="card-img-overlay d-flex align-items-end justify-content-between">
            <h5 class="card-title mb-0">
              Card title
            </h5>
            <p class="card-text">
              Creator Info
            </p>
          </div>
        </div>
        <!-- End card -->
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
