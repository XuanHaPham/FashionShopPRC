<template>
	<div :class="[ openModal ? 'is-active' : '', 'modal' ]">
		<div class="modal-background"></div>
		<div class="modal-card">
			<header class="modal-card-head">
				<p class="modal-card-title">{{ modalTitle }}</p>
				<button class="delete" aria-label="close" @click="closeModal(false)"></button>
			</header>
			<section class="modal-card-body">
				<div v-if="!isCheckoutSection">
					<div class="box" v-for="product in products" :key="product.id">
						<button class="is-pulled-right button is-info is-inverted" @click="removeFromCart(product.id)">{{ removeLabel }}</button>
						<p>{{ product.name }}  {{ product.buyquantity > 0 ?  ` - buyquantity: ${product.buyquantity}` : ''}}</p>
						<p>{{ product.price }} &dollar;</p>
					</div>
					<div v-if="products.length === 0">
						<p>{{ cartEmptyLabel }}</p>
					</div>
				</div>
				<div v-if="isCheckoutSection">
					<p>You bought it :-)</p>
				</div>
			</section>
			<footer class="modal-card-foot">
				<button v-show="products.length > 0 && !isCheckoutSection" class="button is-success" @click="onNextBtn">{{ buyLabel }}</button>
				<button v-if="isCheckoutSection" class="ubtton is-success" @click="closeModal(true)">{{ closeLabel }}</button>
			</footer>
		</div>
	</div>
</template>

<script>
import { base, openapi, methods, routes, setToken, requestToken } from '@/store/index.js'

export default {
	name: 'checkout',
    
	data () {
		return {
			modalTitle: 'Checkout',
			removeLabel: 'Remove from cart',
			cartEmptyLabel: 'Your cart is empty',
			closeLabel: 'Close',
			isCheckoutSection: false
		}
	},

	computed: {
			products () {
				return this.$store.getters.productsAdded;
			},
			openModal () {
				if (this.$store.getters.isCheckoutModalOpen) {
					return true;
				} else {
					return false;
				}
			},
			buyLabel () {
				let totalProducts = this.products.length,
						productsAdded = this.$store.getters.productsAdded,
						pricesArray = [],
						productLabel = '',
						finalPrice = '',
						buyquantity = 1;

				productsAdded.forEach(product => {

					if (product.buyquantity >= 1) {
						buyquantity = product.buyquantity;
					}

					pricesArray.push((product.price * buyquantity)); // get the price of every product added and multiply buyquantity
				});

				finalPrice = pricesArray.reduce((a, b) => a + b, 0); // sum the prices
				
				if (totalProducts > 1) { // set plural or singular
					productLabel = 'products';
				} else {
					productLabel = 'product';
				}
				return `Buy ${totalProducts} ${productLabel} at ${finalPrice}$`;
		},
		isUserLoggedIn () {
			return this.$store.getters.isUserLoggedIn;
		}
	},

	methods: {
		closeModal (reloadPage) {
			this.$store.commit('showCheckoutModal', false);

			if (reloadPage) {
				window.location.reload();
			}
		},
		removeFromCart (id) {
			let data = {
					id: id,
					status: false
			}
			this.$store.commit('removeFromCart', id);
			this.$store.commit('setAddedBtn', data);
		},
		onNextBtn () {
			if (this.isUserLoggedIn) {

			openapi(methods.POST, routes.ORDERS, {
        "products": this.products,
        "accountID": this.getID
        }).then(data => {
        if(data.id !=null){
			  alert("Feedback Success");
			this.isCheckoutSection = true;

        	}
        	else 
  			alert("Feedback Fail");
        });

			}
			 else {
				this.$store.commit('showCheckoutModal', false);
				this.$store.commit('showLoginModal', true);
			}
		},
		onPrevBtn () {
			this.isCheckoutSection = false;
		}
	}
}
</script>

