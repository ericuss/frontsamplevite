import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react-swc';
import path from 'path';
import mkcert from 'vite-plugin-mkcert';
import svgr from 'vite-plugin-svgr';

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
  plugins: [
    react(),
    mkcert(),
    svgr()
  ],
  server: {
    port: 6090
  }
})
