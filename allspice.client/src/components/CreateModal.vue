<template>
  <div
    class="modal fade"
    id="create-modal"
    tabindex="-1"
    role="dialog"
    aria-labelledby="modelTitleId"
    aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">
            <slot name="modal-title"> <!--title slot --></slot>
          </h5>
          <button
            type="button"
            class="btn-close me-1"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <slot name="modal-body"><!--body slot --></slot>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from "../AppState";
import { computed, reactive, onMounted } from "vue";
export default {
  setup() {
    return {};
  },
};
</script>


<style scoped>
</style>