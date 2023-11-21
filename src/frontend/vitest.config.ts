/// <reference types="vitest" />

import { defineConfig } from 'vitest/config';

import path from 'path';

// https://vitejs.dev/config/
export default defineConfig({
  resolve: {
    alias: {
      '@': path.resolve(__dirname, './src'),
      '@assets': path.resolve(__dirname, './src/assets'),
      '@components': path.resolve(__dirname, './src/components'),
      '@pages': path.resolve(__dirname, './src/pages'),
      '@core': path.resolve(__dirname, './src/core'),
    },
  },
  server: {
    port: 6090,
    proxy: {
      '/api': {
        target: 'https://localhost:6443',
        changeOrigin: true,
        rewrite: path => path.replace(/^\/api/, '/api'),
        secure: false
      }
    }
  },
  test: {
    name: 'node',
    root: './',
    environment: 'happy-dom',
    // setupFiles: ['./setup.node.ts'],
    // setupFiles: './setupTest.js',
    include:[
      '**/*.{test,spec}.?(c|m)[jt]s?(x)'
    ]

  }
})
