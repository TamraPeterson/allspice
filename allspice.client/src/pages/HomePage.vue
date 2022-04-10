<template>
  <div class="container-fluid image">
    <div class="row justify-content-center">
      <div class="col-md-2 shadow rounded bg-dark card p-3 m-5 selectable">
        <img
          class="recipeimg"
          src="https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F9%2F2013%2F12%2F06%2F201304-xl-sauce-simmered-spaghetti-al-pomodoro-2000.jpg&q=60"
          alt=""
        />
        <h3 class="text-center">Title</h3>
        <h5 class="text-center">Subtitle</h5>
      </div>
      <div class="col-md-2 shadow rounded bg-dark card p-3 m-5 selectable">
        <img
          class="recipeimg"
          src="https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F9%2F2013%2F12%2F06%2F201304-xl-sauce-simmered-spaghetti-al-pomodoro-2000.jpg&q=60"
          alt=""
        />
        <h3 class="text-center">Title</h3>
        <h5 class="text-center">Subtitle</h5>
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
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
.image {
}
.card {
  opacity: 0.9;
  transition: 0.5s;
}
.card:hover {
  transform: scale(1.05);
  transition: 0.5s;
}
.recipeimg {
  object-fit: cover;
}
</style>
